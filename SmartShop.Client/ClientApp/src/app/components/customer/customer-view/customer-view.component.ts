import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';

import { NotifyService } from '../../../services/common/notify.service';
import { CustomerModel } from '../../../services/data/customer-model';
import { CustomerService } from '../../../services/data/customer.service';


@Component({
  selector: 'app-customer-view',
  templateUrl: './customer-view.component.html',
  styleUrls: ['./customer-view.component.css']
})
export class CustomerViewComponent implements OnInit {
  isLoading:boolean = false;
  customers:CustomerModel[]=[];
  columnList = ["customerName","address", "phone", "userId", "actions"]

  dataSource:MatTableDataSource<CustomerModel> = new MatTableDataSource(this.customers);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private customerService:CustomerService,
    private notifyService:NotifyService
  ) { }
    ngOnInit(): void {
      this.customerService.getCustomer()
        .subscribe(r => {
  
          this.customers = r;
          console.log(this.customers)
          this.dataSource.data = this.customers;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        }, err => {
          this.notifyService.fail("Failed to load customer", "DISMISS");
          throwError(err.error || err);
        });
    }
  
  }
