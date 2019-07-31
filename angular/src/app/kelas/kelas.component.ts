import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { ClassServiceServiceProxy, PagedResultDtoOfKelasDto, KelasDto } from '@shared/service-proxies/service-proxies';
//import { CreateEditTahunAkademikDialogComponent } from './create-edit-tahunakademik/create-edit-tahunakademik-dialog.component';
import { Moment } from 'moment';
import { CreateEditKelasDialogComponent } from './create-edit-kelas/create-edit-kelas-dialog.component';

class PagedKelasRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './kelas.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
      ]
})
export class KelasComponent extends PagedListingComponentBase<KelasDto> {
    classes: KelasDto[] = [];
    keyword = '';

    constructor(
        injector: Injector,
        private _classService: ClassServiceServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    createKelas(): void {
        this.showCreateOrEditKelasDialog();
    }

    editKelas(kelas: KelasDto): void {
        this.showCreateOrEditKelasDialog(kelas.id);
    }

    protected list(
        request: PagedKelasRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;

        this._classService
            .getAll(request.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfKelasDto) => {
                this.classes = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(kelas: KelasDto): void {
        abp.message.confirm(
            this.l('DeleteWarningMessage', kelas.name),
            (result: boolean) => {
                if (result) {
                    this._classService.delete(kelas.id)
                        .subscribe(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        });
                }
            }
        );
    }

    private showCreateOrEditKelasDialog(id?: number): void {
        let createOrEditKelasDialog;
        if (id === undefined || id <= 0) {
            createOrEditKelasDialog = this._dialog.open(CreateEditKelasDialogComponent);
        } else {
            createOrEditKelasDialog = this._dialog.open(CreateEditKelasDialogComponent, {
                data: id
            });
        }

        createOrEditKelasDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}