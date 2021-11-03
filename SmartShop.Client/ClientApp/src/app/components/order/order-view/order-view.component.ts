import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { OrderStatus } from '../../../models/constants/enum-data';
import { CategoryModel } from '../../../models/data/category-model';
import { CustomerModel } from '../../../models/data/customer-model';
import { ConfirmBoolDataModel } from '../../../models/data/input/confirm-bool-data-model';
import { OrderStatusDataModel } from '../../../models/data/input/order-status-data-model';
import { OrderModel } from '../../../models/data/order-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CustomerService } from '../../../services/data/customer.service';
import { OrderService } from '../../../services/data/order.service';

@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})
export class OrderViewComponent implements OnInit {
  orders: OrderModel[] = [];
  customers: CustomerModel[] = [];
  //OrderStaus of options
  orderStatusOptions: { label: string, value: number }[] = [];
  currentStatusOption = OrderStatus.Pending;
  //tack edit
  isConfrimEditTrackList: { id: number, editing: boolean }[] = [];
  orderStatusEditTrackList: { id: number, editing: boolean }[] = [];
  //
  options: boolean[] = [true, false]
  /*
   * Table items
   *
   * */
  dataSource: MatTableDataSource<OrderModel> = new MatTableDataSource(this.orders);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList = ["orderDate", "customerName", "phone","isConfirmed", "orderStatus", "full"]
  constructor(
    private orderService: OrderService,
    private customerService: CustomerService,
    private notifyService: NotifyService
  ) { }
  getStatus(v: number) {
    return OrderStatus[v];
  }
  getCustomerName(id: number) {
    let c = this.customers.find(x => x.customerId == id);
    return c?.customerName || '';
  }
  getCustomerPhone(id: number) {
    let c = this.customers.find(x => x.customerId == id);
    return c?.phone || '';
  }
  /*
   * Methods
   *
   * */
  getIsConfirmEdit(id: number): boolean {
    let o = this.isConfrimEditTrackList.find(x => <number>x.id == id);
    return o?.editing ?? false;
  }
  getOrderStatusEdit(id: number): boolean {
    let o = this.orderStatusEditTrackList.find(x => <number>x.id == id);
    return o?.editing ?? false;
  }
  /*
   * Handler
   *
   * */
  setIsConfirmEditMode(id: number) {
    let o = this.isConfrimEditTrackList.find(x => <number>x.id == id);
    if (o) {
      o.editing = true;
    }
  }
  clearIsConfirmEditMode(id: number) {
    let o = this.isConfrimEditTrackList.find(x => <number>x.id == id);
    if (o) {
      o.editing = false;
    }
  }
  changeIsConfirm(id: number) {
    let o = this.isConfrimEditTrackList.find(x => <number>x.id == id);
    let o1 = this.orders.find(x => <number>x.orderId == id);
    
    console.log(o1?.isConfirmed);
    
    let data: ConfirmBoolDataModel = {
      isConfirm: o1?.isConfirmed
    };
    this.orderService.changeOrderConfirmation(id, data)
      .subscribe(r => {
        this.notifyService.success("Order confirmation status canged", "DISMISS");
        if (o) o.editing = false;;
      }, err => {
        this.notifyService.fail(`Falied to cahnge orders confirmation`, "DISMISS");
        throwError(err.error || err);
      });
  }
  setOrderStatusEditMode(id: number) {
    let o = this.orderStatusEditTrackList.find(x => <number>x.id == id);
    if (o) {
      o.editing = true;
    }
  }
  clearOrderStatusEditMode(id: number) {
    let o = this.orderStatusEditTrackList.find(x => <number>x.id == id);
    if (o) {
      o.editing = false;
    }
  }
  changeOrderStatus(id: number) {
    let o = this.isConfrimEditTrackList.find(x => <number>x.id == id);
    let o1 = this.orders.find(x => <number>x.orderId == id);
    let i = this.orderStatusEditTrackList.findIndex(x => <number>x.id == id);
    let data: OrderStatusDataModel = {
      status: o1?.orderStatus
    };
    this.orderService.changeOrderStatus(<number>o1?.orderId, data)
      .subscribe(r => {
        this.notifyService.success("Order status canged", "DISMISS");
        if (o) o.editing = false;
        
        if (o1?.orderStatus != this.currentStatusOption) {
          this.dataSource.data = this.dataSource.data.filter(x => x.orderStatus != o1?.orderStatus);
          this.orderStatusEditTrackList.splice(i, 1);
        }
      }, err => {
        this.notifyService.fail(`Falied to cahnge orders status`, "DISMISS");
        throwError(err.error || err);
      })
  }
  orderStatusCanged(event: any) {
    this.currentStatusOption = event.value
    console.log(this.currentStatusOption);
    this.orderService.getOfStatus(this.currentStatusOption)
      .subscribe(r => {
        this.orders = r;
        this.dataSource.data = this.orders;
        this.isConfrimEditTrackList = [];
        this.orderStatusEditTrackList = [];
        this.setEditTrackList();
      }, err => {
        this.notifyService.fail(`Falied to load ${OrderStatus[this.currentStatusOption]} orders`, "DISMISS");
        throwError(err.error || err);
      });
  }
  setEditTrackList() {
    this.orders.forEach(o => {
      this.isConfrimEditTrackList.push({ id: <number>o.orderId, editing: false });
      this.orderStatusEditTrackList.push({ id: <number>o.orderId, editing: false });
    });
  }
  ngOnInit(): void {
    Object.keys(OrderStatus).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    ).forEach((v: any, i) => {
      this.orderStatusOptions.push({ label: v, value: Number(OrderStatus[v]) });
    });
    this.orderService.getPending()
      .subscribe(r => {
        this.orders = r;
        this.setEditTrackList();
        this.dataSource.data = this.orders;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, err => {
        this.notifyService.fail("Falied to load pending orders", "DISMISS");
        throwError(err.error || err);
      });
    this.customerService.getCustomer()
      .subscribe(r => {
        this.customers = r;
      }, err => {
        this.notifyService.fail("Falied to load customer", "DISMISS");
        throwError(err.error || err);
      });
  }

}
