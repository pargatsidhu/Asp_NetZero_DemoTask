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
    CountryServiceProxy,
    GetCountryForEditOutput,
    CountryDto,    
    CountryEditDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'edit-country-modal.component.html'
  })
  export class EditCountryModalComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    id: number;
    country = new CountryEditDto();
   
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _countryService: CountryServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
      this._countryService
        .getCountryForEdit(this.id)
        .subscribe((result: GetCountryForEditOutput) => {
          this.country = result.country;          
        });
    }
  
  
    
  
    save(): void {
      this.saving = true;
  
      const country = new CountryDto();
      country.init(this.country);
      this._countryService
        .editCountry(country)
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
  