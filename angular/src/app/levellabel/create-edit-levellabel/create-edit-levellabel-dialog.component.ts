import { Component, Injector, OnInit, Optional, Inject } from '@angular/core';
import { MatDialogRef, MatCheckboxChange, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
    LevelLabelServiceProxy,
    CreateLevelLabelDto,
    LevelLabelDto,
    LevelDto
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './create-edit-levellabel-dialog.component.html',
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
export class CreateEditLevelLabelDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    levellabel: CreateLevelLabelDto = new CreateLevelLabelDto();
    levels: LevelDto[] = [];

    constructor(
        injector: Injector,
        public _levelLabelService: LevelLabelServiceProxy,
        private _dialogRef: MatDialogRef<CreateEditLevelLabelDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(): void {
        if (this._id === undefined || this._id <= 0) {

        } else {
            this._levelLabelService.get(this._id).subscribe(result => {
                this.levellabel = result;
            });
        }

        this._levelLabelService.getAllLevels().subscribe(result => {
            this.levels = result;
        })
    }

    compareLevel = (val1: string, val2: number) => {
        if (val1 && val2) {
            return val1 === val2.toString();
        } else {
            return false;
        }

    }

    save(): void {
        this.saving = true;

        if (this._id === undefined || this._id <= 0) {
            this._levelLabelService
                .create(this.levellabel)
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
            let levelLabelDto = new LevelLabelDto();
            levelLabelDto.id = this.levellabel.id;
            levelLabelDto.levelId = this.levellabel.levelId;
            levelLabelDto.name = this.levellabel.name;

            this._levelLabelService
                .update(levelLabelDto)
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
