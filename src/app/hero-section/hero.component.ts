import {Component, OnInit, output} from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-hero-section',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css'
})
export class HeroComponent implements OnInit {
  requestPage = output<void>();
  previousRequestID : string | null = null;

  ngOnInit() {
    this.previousRequestID = window.localStorage.getItem('requestID');
  }


  onRequestHelp() {
    if (!this.previousRequestID) {
      this.requestPage.emit();
    }
    else {
      console.log('Request already submitted');
    }
  }
}
