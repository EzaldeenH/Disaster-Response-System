import { Routes } from '@angular/router';
import {DonorFormComponent} from "./donation/donor-form/donor-form.component";
import {DonationFormComponent} from "./donation/donation-form/donation-form.component";
import {RequestFormComponent} from "./hero-section/request-form/request-form.component";

export const routes: Routes = [
  {
    path: 'donor-registration',
    component: DonorFormComponent,
    outlet: 'popup'
  },
  {
    path: 'donation-form',
    component: DonationFormComponent,
    outlet: 'popup'
  },
  {
    path: 'request-form',
    component: RequestFormComponent
  }
];
