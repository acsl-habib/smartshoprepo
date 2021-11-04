import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { throwError } from 'rxjs';
import { PaymentModel } from 'src/app/models/data/payment-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PaymentService } from 'src/app/services/data/payment.service';

@Component({
  selector: 'app-payment-create',
  templateUrl: './payment-create.component.html',
  styleUrls: ['./payment-create.component.css']
})
export class PaymentCreateComponent implements OnInit {
  payment: PaymentModel = new PaymentModel();
  constructor(
    private paymentService: PaymentService,
    private notifyService: NotifyService
  ) { }

  insert(f: NgForm) {
    this.paymentService.create(this.payment)
      .subscribe(r => {
        this.notifyService.success("Data saved successfully", "DISMISS");
        f.form.reset({});
        f.form.markAsUntouched();
        f.form.markAsPristine();
      }, err => {
        this.notifyService.fail("Failed to update data", "DISMISS");
        throwError(err.error || err);
      })
  }

  ngOnInit(): void {
  }

}
