import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { LevelLabelServiceProxy, PagedResultDtoOfLevelLabelDto, LevelLabelDto, LevelDto } from '@shared/service-proxies/service-proxies';
import { Moment } from 'moment';
import { finished } from 'stream';
import { CreateEditLevelLabelDialogComponent } from './create-edit-levellabel/create-edit-levellabel-dialog.component';
//import { CreateEditKelasDialogComponent } from './create-edit-kelas/create-edit-kelas-dialog.component';

class PagedLevelLabelRequestDto extends PagedRequestDto {
    keyword: string;
    levelId: number;
}

@Component({
    templateUrl: './levellabel.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
      ]
})
export class LevelLabelComponent extends PagedListingComponentBase<LevelLabelDto> implements OnInit {
    levellabels: LevelLabelDto[] = [];
    keyword = '';
    levelId = 0;
    levels: LevelDto[] = [];

    constructor(
        injector: Injector,
        private _levelLabelService: LevelLabelServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);

    }

    createLevelLabel(): void {
        this.showCreateOrEditLevelLabelDialog();
    }

    editLevelLabel(levellabel: LevelLabelDto): void {
        this.showCreateOrEditLevelLabelDialog(levellabel.id);
    }

    ngOnInit(): void {
        this._levelLabelService
            .getAllLevels()
            .pipe(
                finalize(() => {
                    
                })
            )
            .subscribe((result: LevelDto[]) => {
                this.levels = result;
            })

        super.ngOnInit();
    }

    protected list(
        request: PagedLevelLabelRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;
        request.levelId = this.levelId;

        this._levelLabelService
            .getAll(request.keyword, request.levelId, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfLevelLabelDto) => {
                this.levellabels = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(levelLabel: LevelLabelDto): void {
        abp.message.confirm(
            this.l('DeleteWarningMessage', levelLabel.name),
            (result: boolean) => {
                if (result) {
                    this._levelLabelService.delete(levelLabel.id)
                        .subscribe(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        });
                }
            }
        );
    }

    private showCreateOrEditLevelLabelDialog(id?: number): void {
        let createOrEditLevelLabelDialog;
        if (id === undefined || id <= 0) {
            createOrEditLevelLabelDialog = this._dialog.open(CreateEditLevelLabelDialogComponent);
        } else {
            createOrEditLevelLabelDialog = this._dialog.open(CreateEditLevelLabelDialogComponent, {
                data: id
            });
        }

        createOrEditLevelLabelDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}