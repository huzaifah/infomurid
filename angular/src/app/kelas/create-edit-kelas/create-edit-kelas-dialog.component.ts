import { Component, Injector, OnInit, Optional, Inject } from '@angular/core';
import { MatDialogRef, MatCheckboxChange, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
    ClassServiceServiceProxy,
    CreateKelasDto,
    KelasDto
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './create-edit-kelas-dialog.component.html',
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
export class CreateEditKelasDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    kelas: CreateKelasDto = new CreateKelasDto();

    constructor(
        injector: Injector,
        public _classService: ClassServiceServiceProxy,
        private _dialogRef: MatDialogRef<CreateEditKelasDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(): void {
        if (this._id === undefined || this._id <= 0) {

        } else {
            this._classService.get(this._id).subscribe(result => {
                this.kelas = result;
            });
        }
    }

    compareTahap = (val1: string, val2: number) => {
        if (val1 && val2) {
            return val1 === val2.toString();
        } else {
            return false;
        }

    }

    save(): void {
        this.saving = true;

        if (this._id === undefined || this._id <= 0) {
            this._classService
                .create(this.kelas)
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
            let kelasDto = new KelasDto();
            kelasDto.id = this.kelas.id;
            kelasDto.name = this.kelas.name;
            kelasDto.code = this.kelas.code;
            kelasDto.tahap = this.kelas.tahap;

            this._classService
                .update(kelasDto)
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
