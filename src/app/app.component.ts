import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HeaderComponent} from "./header/header.component";
import {HeroComponent} from "./hero/hero.component";
import {FaqComponent} from "./faq/faq.component";
import {DonationComponent} from "./donation/donation.component";
import {NewsComponent} from "./news/news.component";
import {FooterComponent} from "./footer/footer.component";
import {DonorFormComponent} from "./donor-form/donor-form.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, HeroComponent, FaqComponent, DonationComponent, NewsComponent, FooterComponent, DonorFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'DisasterResponseSystem';
}
