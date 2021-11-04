import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { PaymentModel } from 'src/app/models/data/payment-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PaymentService } from 'src/app/services/data/payment.service';

@Component({
  selector: 'app-payment-view',
  templateUrl: './payment-view.component.html',
  styleUrls: ['./payment-view.component.css']
})
export class PaymentViewComponent implements OnInit {
  isLoading:boolean = false;
  payments:PaymentModel[] = [];
  columnList = ["paymentName", "shortName", "paymentType","accountNo","actions"]

  dataSource:MatTableDataSource<PaymentModel> = new MatTableDataSource(this.payments);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private paymentService:PaymentService,
    private notifyService:NotifyService,
    private dailogRef: MatDialog
  ) { }

  delete(item: PaymentModel) {
    this.dailogRef.open(ConfirmDialogComponent, {
      width: "400px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.paymentService.delete(Number(item.paymentId))
            .subscribe(
              r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.paymentId != item.paymentId);
                this.notifyService.success("successfully deleted", "DISMISS")
              },
              err => {
                this.notifyService.fail("Failed to delete data", "DISMISS");
                throwError(err.error || err);
              });
        }
      });
  }

  ngOnInit(): void {
    this.isLoading=true;
    this.paymentService.get()
    .subscribe(
      r=>{
        this.payments = r;
        this.dataSource.data = this.payments;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator= this.paginator;
        this.isLoading=false;
      },
      err=>{
        this.isLoading=false;
        this.notifyService.fail("Failed to load payment", "DISMISS");
        throwError(err.error||err);

      }
    )
  }

}
