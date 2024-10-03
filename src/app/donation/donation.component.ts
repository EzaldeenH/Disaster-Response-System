import {Component, OnInit} from '@angular/core';
import {DonationFormComponent} from "../donation-form/donation-form.component";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-donation',
  standalone: true,
  imports: [
    DonationFormComponent,
    RouterLink
  ],
  templateUrl: './donation.component.html',
  styleUrl: './donation.component.css'
})
export class DonationComponent implements OnInit {
  link = '';

  ngOnInit() {
    const donorID = localStorage.getItem('donorID');

    if (donorID) {
      this.link = "/donation-form";
    }
    else {
      this.link = "/donor-registration";
    }
  }

}
