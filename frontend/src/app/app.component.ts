import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./header/header.component";
import { HeroComponent } from "./hero-section/hero.component";
import { FaqComponent } from "./faq/faq.component";
import { DonationComponent } from "./donation/donation.component";
import { NewsComponent } from "./news/news.component";
import { FooterComponent } from "./footer/footer.component";
import { DonorFormComponent } from "./donation/donor-form/donor-form.component";
import { DonationFormComponent } from "./donation/donation-form/donation-form.component";
import { RequestFormComponent } from "./hero-section/request-form/request-form.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, HeroComponent, FaqComponent, DonationComponent, NewsComponent, FooterComponent, DonorFormComponent, DonationFormComponent, RequestFormComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DisasterResponseSystem';
  isAddingRequest = false;

  onRequestForm() {
    this.isAddingRequest = true;
    console.log(this.isAddingRequest);
  }

  onCloseRequestForm() {
    this.isAddingRequest = false;
    console.log(this.isAddingRequest);
  }
}
