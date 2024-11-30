import { Component, OnInit } from '@angular/core';
import { SpinnerService } from '../shared/service/spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  standalone: false,
  styleUrl: './spinner.component.css'
})
export class SpinnerComponent implements OnInit {
  showSpinner = false;

  constructor(private spinnerService: SpinnerService) { }

  ngOnInit() {
    this.spinnerService.spinnerState$.subscribe(state => {
      this.showSpinner = state;
    });
  }
}
