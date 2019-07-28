import { Component, Injector, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
    templateUrl: './underconstruction.component.html',
    animations: [appModuleAnimation()]
})
export class UnderConstructionComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}