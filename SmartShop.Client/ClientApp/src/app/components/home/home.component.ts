import { Component, OnInit } from '@angular/core';
import { throwError } from 'rxjs';
import { UserModel } from '../../models/authentication/user-model';
import { NotifyService } from '../../services/common/notify.service';
import { OrderService } from '../../services/data/order.service';
import { SignalrService } from '../../services/persistent/signalr.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  data!: UserModel;
  pendingOrders: number = 0;
  constructor(
    private orderSevice: OrderService,
    private signalrService: SignalrService,
    private notifyService:NotifyService
  ) {
    //do nothing
  }
  loadPendingOrder() {
    this.orderSevice.getPendingCount()
      .subscribe(r => {
        this.pendingOrders = r;
      }, err => {
        this.notifyService.fail("Failed to load pending order count", "DISMISS");
        throwError(err.error || err);
      });
  }
  ngOnInit() {
    this.loadPendingOrder();
    this.signalrService.orderEvent.subscribe(x => {
      console.log(x);
      this.loadPendingOrder();
    });
  }
}
