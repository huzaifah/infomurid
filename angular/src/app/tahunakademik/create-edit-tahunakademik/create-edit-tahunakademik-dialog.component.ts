import { Component, Injector, OnInit, Optional, Inject } from '@angular/core';
import { MatDialogRef, MatCheckboxChange, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  AcademicYearServiceProxy,
  CreateTahunAkademikDto,
  TahunAkademikDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './create-edit-tahunakademik-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CreateEditTahunAkademikDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  tahunAkademik: CreateTahunAkademikDto = new CreateTahunAkademikDto();

  constructor(
    injector: Injector,
    public _academicYearService: AcademicYearServiceProxy,
    private _dialogRef: MatDialogRef<CreateEditTahunAkademikDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    if (this._id === undefined || this._id <= 0) {
      this.tahunAkademik.isLocked = false;
    } else {
      this._academicYearService.get(this._id).subscribe(result => {
        this.tahunAkademik = result;
      });
    }
  }

  save(): void {
    this.saving = true;

    if (this._id === undefined || this._id <= 0) {
      this._academicYearService
      .create(this.tahunAkademik)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
    } else {
      let tahunAkademikDto = new TahunAkademikDto();
      tahunAkademikDto.id = this.tahunAkademik.id;
      tahunAkademikDto.year = this.tahunAkademik.year;
      tahunAkademikDto.isLocked = this.tahunAkademik.isLocked;

      this._academicYearService
      .update(tahunAkademikDto)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
    }
    
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}
