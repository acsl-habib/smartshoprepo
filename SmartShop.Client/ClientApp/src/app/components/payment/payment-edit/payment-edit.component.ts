import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { PaymentModel } from 'src/app/models/data/payment-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PaymentService } from 'src/app/services/data/payment.service';

@Component({
  selector: 'app-payment-edit',
  templateUrl: './payment-edit.component.html',
  styleUrls: ['./payment-edit.component.css']
})
export class PaymentEditComponent implements OnInit {

  payment!: PaymentModel;
  constructor(
    private paymentService: PaymentService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }

  update(f: NgForm) {
    this.paymentService.update(this.payment)
      .subscribe(r => {
        this.notifyService.success("Data updated successfully", "DISMISS");
        f.form.markAsUntouched();
        f.form.markAsPristine();
      }, err => {
        this.notifyService.fail("Failed to update data", "DISMISS");
        throwError(err.error || err);
      })
  }

  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.paymentService.getById(id)
      .subscribe(
        r => {
          this.payment = r;
        },
        err => {
          this.notifyService.fail("Failed to load payment data", "DISMISS");
          throwError(err.error || err);
        })
  }

}
