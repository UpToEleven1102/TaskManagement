import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-new-user-modal',
  templateUrl: './new-user-modal.component.html',
  styleUrls: ['./new-user-modal.component.css']
})
export class NewUserModalComponent implements OnInit {
  @Input() noBackButton = false;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  onSuccess(success: boolean): void {
    if (success) {
      this.activeModal.close(success);
    }
  }
}
