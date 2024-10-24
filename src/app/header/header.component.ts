import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  donationLink = '';

  ngOnInit() {
    const donorID = localStorage.getItem('donorID');

    if (donorID) {
      this.donationLink = "donation-form";
    }
    else {
      this.donationLink = "donor-registration";
    }
  }


}
