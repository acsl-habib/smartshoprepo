import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { ShippingModel } from 'src/app/models/data/shipping-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ShippingService } from 'src/app/services/data/shipping.service';

@Component({
  selector: 'app-shipping-edit',
  templateUrl: './shipping-edit.component.html',
  styleUrls: ['./shipping-edit.component.css']
})
export class ShippingEditComponent implements OnInit {

  shipping!: ShippingModel;
  constructor(
    private shippingService: ShippingService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }

  update(f: NgForm) {
    this.shippingService.update(this.shipping)
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
    this.shippingService.getById(id)
      .subscribe(
        r => {
          this.shipping = r;
        },
        err => {
          this.notifyService.fail("Failed to load shipping data", "DISMISS");
          throwError(err.error || err);
        })
  }

}
