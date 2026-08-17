import { Component, inject } from '@angular/core';

import { AlertBarComponent } from './alert-bar/alert-bar.component';
import { HeaderComponent } from './header/header.component';
import { HeroComponent } from './hero-section/hero.component';
import { ImpactStatsComponent } from './impact-stats/impact-stats.component';
import { MissionComponent } from './mission/mission.component';
import { FaqComponent } from './faq/faq.component';
import { DonationComponent } from './donation/donation.component';
import { TestimonialsComponent } from './testimonials/testimonials.component';
import { NewsComponent } from './news/news.component';
import { FooterComponent } from './footer/footer.component';

import { DonorFormComponent } from './donation/donor-form/donor-form.component';
import { DonationFormComponent } from './donation/donation-form/donation-form.component';
import { RequestStatusComponent } from './header/request-status/request-status.component';
import { RequestFormComponent } from './hero-section/request-form/request-form.component';
import { ModalService } from './modal.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    AlertBarComponent,
    HeaderComponent,
    HeroComponent,
    ImpactStatsComponent,
    MissionComponent,
    FaqComponent,
    DonationComponent,
    TestimonialsComponent,
    NewsComponent,
    FooterComponent,
    DonorFormComponent,
    DonationFormComponent,
    RequestStatusComponent,
    RequestFormComponent,
  ],
  templateUrl: './app.component.html',
})
export class AppComponent {
  readonly modal = inject(ModalService);

  //test watch path
}
