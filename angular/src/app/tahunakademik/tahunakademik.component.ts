import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { AcademicYearServiceProxy, TahunAkademikDto, PagedResultDtoOfTahunAkademikDto } from '@shared/service-proxies/service-proxies';
import { CreateEditTahunAkademikDialogComponent } from './create-edit-tahunakademik/create-edit-tahunakademik-dialog.component';
import { Moment } from 'moment';

class PagedTahunAkademikRequestDto extends PagedRequestDto {
    keyword: string;
    isLocked: boolean | null;
}

@Component({
    templateUrl: './tahunakademik.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
      ]
})
export class TahunAkademikComponent extends PagedListingComponentBase<TahunAkademikDto> {
    academicYears: TahunAkademikDto[] = [];
    keyword = '';
    isLocked: boolean | null;

    constructor(
        injector: Injector,
        private _academicYearService: AcademicYearServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    createTahunAkademik(): void {
        this.showCreateOrEditTahunAkademikDialog();
    }

    editTahunAkademik(tahunAkademik: TahunAkademikDto): void {
        this.showCreateOrEditTahunAkademikDialog(tahunAkademik.id);
    }

    protected list(
        request: PagedTahunAkademikRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;
        request.isLocked = this.isLocked;

        this._academicYearService
            .getAll(request.keyword, request.isLocked, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfTahunAkademikDto) => {
                this.academicYears = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(tahunAkademik: TahunAkademikDto): void {
        abp.message.confirm(
            this.l('DeleteWarningMessage', tahunAkademik.year),
            (result: boolean) => {
                if (result) {
                    this._academicYearService.delete(tahunAkademik.id)
                        .subscribe(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        });
                }
            }
        );
    }

    private showCreateOrEditTahunAkademikDialog(id?: number): void {
        let createOrEditTahunAkademikDialog;
        if (id === undefined || id <= 0) {
            createOrEditTahunAkademikDialog = this._dialog.open(CreateEditTahunAkademikDialogComponent);
        } else {
            createOrEditTahunAkademikDialog = this._dialog.open(CreateEditTahunAkademikDialogComponent, {
                data: id
            });
        }

        createOrEditTahunAkademikDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}
