
import { Component, Injector, ChangeDetectionStrategy, OnInit  } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { StateServiceProxy, StateDto, StateListDto, StateListDtoListResultDto, CountryServiceProxy, CountryListDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

  import { CreateStateModalComponent } from './create-state/create-state-modal.component';
  import { EditStateModalComponent } from './edit-state/edit-state-modal.component';
@Component({
    templateUrl: './state.component.html',
    //animations: [appModuleAnimation()],
    //changeDetection: ChangeDetectionStrategy.OnPush
})

export class StateComponent extends AppComponentBase  implements OnInit {

    states: StateListDto[] = [];
    
    filter: string = '';

    constructor(
        injector: Injector,
        private _stateService: StateServiceProxy,
        
        private _modalService: BsModalService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getStates();
    }
    createState(): void {
        this.showCreateOrEditRoleDialog();
      }
      editState(state: StateDto): void {
        this.showCreateOrEditRoleDialog(state.id);
      }
    getStates(): void {
        this._stateService.getStates(this.filter).subscribe((result) => {
            this.states = result.items;
            console.log(this.states);
        });
    }
    filterStates():void{
       
        this.getStates();
    }
    
    showCreateOrEditRoleDialog(id?: number): void {
        let createOrEditRoleDialog: BsModalRef;
        if (!id) {
          createOrEditRoleDialog = this._modalService.show(
            CreateStateModalComponent,
            {
              class: 'modal-lg',
            }
          );
        }
         else {
          createOrEditRoleDialog = this._modalService.show(
            EditStateModalComponent,
            {
              class: 'modal-lg',
              initialState: {
                id: id,
              },
            }
          );
        }
    
        createOrEditRoleDialog.content.onSave.subscribe(() => {
          this.getStates();
        });
      }
      delete(state: StateDto): void {
        abp.message.confirm(
          this.l('StateDeleteWarningMessage', state.name),
          undefined,
          (result: boolean) => {
            if (result) {
              this._stateService
                .deleteState(state.id)
                .pipe(
                  finalize(() => {
                    abp.notify.success(this.l('SuccessfullyDeleted'));
                    this.getStates();
                  })
                )
                .subscribe(() => {});
            }
          }
        );
      }
}
