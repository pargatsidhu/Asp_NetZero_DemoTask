import {
    Component,
    Injector,
    OnInit,
    EventEmitter,
    Output,
  } from '@angular/core';
  import { finalize } from 'rxjs/operators';
  import { BsModalRef } from 'ngx-bootstrap/modal';
  import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
  import { AppComponentBase } from '@shared/app-component-base';
  import {
    StateServiceProxy,
    GetStateForEditOutput,
    StateDto,    
    StateEditDto,
    CountryServiceProxy,
    CountryListDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'edit-state-modal.component.html'
  })
  export class EditStateModalComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    countries: CountryListDto[] = [];
    id: number;
    state = new StateEditDto();
   
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _stateService: StateServiceProxy,
      private _countryService: CountryServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
        this.getCountries();
      this._stateService
        .getStateForEdit(this.id)
        .subscribe((result: GetStateForEditOutput) => {        
          this.state = result.state;          
        });
    }
    
    getCountries(): void {
        this._countryService.getCountries('').subscribe((result) => {
            this.countries = result.items;            
        });
    }
  
  
    
  
    save(): void {
      this.saving = true;
  
      const state = new StateDto();
      state.init(this.state);
      this._stateService
        .editState(state)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe(() => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        });
    }
  }
  