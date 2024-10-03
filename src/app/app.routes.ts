import { Routes } from '@angular/router';
import {DonorFormComponent} from "./donor-form/donor-form.component";
import {DonationFormComponent} from "./donation-form/donation-form.component";

export const routes: Routes = [
  {
    path: 'donor-registration',
    component: DonorFormComponent,
  },
  {
    path: 'donation-form',
    component: DonationFormComponent
  }
];
