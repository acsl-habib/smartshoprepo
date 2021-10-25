import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { throwError } from 'rxjs';
import { ShippingModel } from 'src/app/models/data/shipping-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ShippingService } from 'src/app/services/data/shipping.service';

@Component({
  selector: 'app-shipping-create',
  templateUrl: './shipping-create.component.html',
  styleUrls: ['./shipping-create.component.css']
})
export class ShippingCreateComponent implements OnInit {
  shipping: ShippingModel = new ShippingModel();
  constructor(
    private shippingService: ShippingService,
    private notifyService: NotifyService
  ) { }

  insert(f: NgForm) {
    this.shippingService.create(this.shipping)
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
