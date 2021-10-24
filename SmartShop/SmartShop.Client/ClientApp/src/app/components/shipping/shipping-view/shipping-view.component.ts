import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { ShippingModel } from 'src/app/models/data/shipping-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ShippingService } from 'src/app/services/data/shipping.service';

@Component({
  selector: 'app-shipping-view',
  templateUrl: './shipping-view.component.html',
  styleUrls: ['./shipping-view.component.css']
})
export class ShippingViewComponent implements OnInit {
  isLoading:boolean = false;
  shippings:ShippingModel[] = [];
  columnList = ["shippingAddress", "shippingCost", "actions"]

  dataSource:MatTableDataSource<ShippingModel> = new MatTableDataSource(this.shippings);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private shippingService:ShippingService,
    private notifyService:NotifyService,
    private dailogRef: MatDialog
  ) { }

  delete(item: ShippingModel) {
    this.dailogRef.open(ConfirmDialogComponent, {
      width: "400px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.shippingService.delete(Number(item.shippingId))
            .subscribe(
              r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.shippingId != item.shippingId);
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
    this.shippingService.get()
    .subscribe(
      r=>{
        this.shippings = r;
        this.dataSource.data = this.shippings;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator= this.paginator;
        this.isLoading=false;
      },
      err=>{
        this.isLoading=false;
        this.notifyService.fail("Failed to load shipping", "DISMISS");
        throwError(err.error||err);

      }
    )
  }

}
