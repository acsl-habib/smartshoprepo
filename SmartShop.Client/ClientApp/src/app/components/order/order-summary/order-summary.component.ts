import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { OrderSummaryModel } from '../../../models/data/viewmodels/order-summary-model';
import { NotifyService } from '../../../services/common/notify.service';
import { OrderService } from '../../../services/data/order.service';

@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.css']
})
export class OrderSummaryComponent implements OnInit {
  order: OrderSummaryModel = {};
  constructor(
    private orderService: OrderService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  getTotal() {
    let sum = 0;
    this.order.orderDetails?.forEach(o => {
      sum += (o.productPrice ?? 0) * (o.quantity ?? 0);
    });
    return sum;
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.orderService.getOrderSummary(id)
      .subscribe(r => {
        this.order = r;
        console.log(this.order);
        this.order.orderDetails?.forEach(x => {
          console.log(x.productPrice)
        })
      }, err => {
        this.notifyService.fail("Failed to delete data", "DISMISS");
        throwError(err.error || err);
      })
  }

}
