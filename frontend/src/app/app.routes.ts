import { Routes } from '@angular/router';
import { BigFeatureComponent } from './big-feature/big-feature.component';

/**
 * The app is a single-page landing. Modals (donor registration, donation
 * form, request status, request form) are now driven by the ModalService
 * + PrimeNG dialogs instead of named router outlets, so there are no
 * routes here.
 *
 * ...except for THE BIG FEATURE (which is actually big).
 */
export const routes: Routes = [
  { path: 'big-feature', component: BigFeatureComponent },
];
