import { Component, OnInit, Injector, ElementRef, Output, EventEmitter } from '@angular/core';

import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CountryServiceProxy,
    CountryDto,
    CreateCountryDto
  } from '@shared/service-proxies/service-proxies';
  import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
    //selector: 'createCountryModal',
    templateUrl: './create-country-modal.component.html'
})
export class CreateCountryModalComponent extends AppComponentBase implements OnInit {
    saving = false;
    country = new CountryDto();       
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _countryService: CountryServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
    //   this._countryService
    //     .getAllPermissions()
    //     .subscribe((result: PermissionDtoListResultDto) => {
    //       this.permissions = result.items;
    //       this.setInitialPermissionsStatus();
    //     });
    }
  
    // setInitialPermissionsStatus(): void {
    //   _map(this.permissions, (item) => {
    //     this.checkedPermissionsMap[item.name] = this.isPermissionChecked(
    //       item.name
    //     );
    //   });
    // }
  
    // isPermissionChecked(permissionName: string): boolean {
    //   // just return default permission checked status
    //   // it's better to use a setting
    //   return this.defaultPermissionCheckedStatus;
    // }
  
    // onPermissionChange(permission: PermissionDto, $event) {
    //   this.checkedPermissionsMap[permission.name] = $event.target.checked;
    // }
  
    // getCheckedPermissions(): string[] {
    //   const permissions: string[] = [];
    //   _forEach(this.checkedPermissionsMap, function (value, key) {
    //     if (value) {
    //       permissions.push(key);
    //     }
    //   });
    //   return permissions;
    // }
  
    save(): void {
      this.saving = true;
  
      const country = new CreateCountryDto();
      country.init(this.country);
     // role.grantedPermissions = this.getCheckedPermissions();
  
      this._countryService
        .create(country)
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