
import { Component, Injector, ChangeDetectionStrategy, OnInit  } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CountryServiceProxy, CountryDto,CountryListDto, CountryListDtoListResultDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

  import { CreateCountryModalComponent } from './create-country/create-country-modal.component';
  import { EditCountryModalComponent } from './edit-country/edit-country-modal.component';
@Component({
    templateUrl: './country.component.html',
    //animations: [appModuleAnimation()],
    //changeDetection: ChangeDetectionStrategy.OnPush
})

export class CountryComponent extends AppComponentBase  implements OnInit {

    countries: CountryListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _countryService: CountryServiceProxy,
        private _modalService: BsModalService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getCountries();
    }
    createCountry(): void {
        this.showCreateOrEditRoleDialog();
      }
      editCountry(country: CountryDto): void {
        this.showCreateOrEditRoleDialog(country.id);
      }
    getCountries(): void {
        this._countryService.getCountries(this.filter).subscribe((result) => {
            this.countries = result.items;
            console.log(this.countries);
        });
    }
    filterCountries():void{
        this.getCountries();
    }
    showCreateOrEditRoleDialog(id?: number): void {
        let createOrEditRoleDialog: BsModalRef;
        if (!id) {
          createOrEditRoleDialog = this._modalService.show(
            CreateCountryModalComponent,
            {
              class: 'modal-lg',
            }
          );
        }
         else {
          createOrEditRoleDialog = this._modalService.show(
            EditCountryModalComponent,
            {
              class: 'modal-lg',
              initialState: {
                id: id,
              },
            }
          );
        }
    
        createOrEditRoleDialog.content.onSave.subscribe(() => {
          this.getCountries();
        });
      }
      delete(country: CountryDto): void {
        abp.message.confirm(
          this.l('CountryDeleteWarningMessage', country.name),
          undefined,
          (result: boolean) => {
            if (result) {
              this._countryService
                .deleteCountry(country.id)
                .pipe(
                  finalize(() => {
                    abp.notify.success(this.l('SuccessfullyDeleted'));
                    this.getCountries();
                  })
                )
                .subscribe(() => {});
            }
          }
        );
      }
}
