import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { BrandModel } from 'src/app/models/data/brand-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BrandService } from 'src/app/services/data/brand.service';

@Component({
  selector: 'app-brand-view',
  templateUrl: './brand-view.component.html',
  styleUrls: ['./brand-view.component.css']
})
export class BrandViewComponent implements OnInit {

  isLoading:boolean = false;
  brands:BrandModel[]=[];
  columnList = ["brandName","products", "actions"]
  /*
   * Table items
   *
   * */
  dataSource:MatTableDataSource<BrandModel> = new MatTableDataSource(this.brands);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private brandService:BrandService,
    private notifyService:NotifyService,
    private matDialog: MatDialog
  ) { }
  confirmDelete(item: BrandModel): void {
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(s => {
        if (s) {
          this.brandService.delete(Number(item.brandId))
            .subscribe(s => {
              this.dataSource.data = this.dataSource.data.filter(b => b.brandId != item.brandId);
              this.notifyService.success("Brand has been Deleted", "DISMISS")
            }, Error => {
              this.notifyService.fail("Failed to Delete Brand", "DISMISS")
            });
        }
      });
  }
 
  ngOnInit(): void {
    this.isLoading=true;
    this.brandService.get()
    .subscribe(
      r=>{
        this.brands = r;
        this.dataSource.data = this.brands;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator= this.paginator;
        this.isLoading=false;
      },
      err=>{
        this.isLoading=false;
        this.notifyService.fail("Failed to load brands", "DISMISS");
        throwError(err.error||err);

      }
    )
  }

}
