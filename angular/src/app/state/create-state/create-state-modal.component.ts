import { Component, OnInit, Injector, ElementRef, Output, EventEmitter } from '@angular/core';

import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
    StateServiceProxy,
    StateDto,
    CreateStateDto,
    CountryServiceProxy,
    CountryListDto
  } from '@shared/service-proxies/service-proxies';
  import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({    
    templateUrl: './create-state-modal.component.html'
})
export class CreateStateModalComponent extends AppComponentBase implements OnInit {
    saving = false;
    countries: CountryListDto[] = [];
    state = new StateDto();       
  
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
    }
    getCountries(): void {
        this._countryService.getCountries('').subscribe((result) => {
            this.countries = result.items;            
        });
    }
    save(): void {
      this.saving = true;
  
      const state = new CreateStateDto();
      state.init(this.state);            
     // role.grantedPermissions = this.getCheckedPermissions();
  
      this._stateService
        .create(state)
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