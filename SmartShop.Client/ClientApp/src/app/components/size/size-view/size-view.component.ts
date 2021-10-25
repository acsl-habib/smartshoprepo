import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { SizeModel } from 'src/app/models/data/size-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { SizeService } from 'src/app/services/data/size.service';

@Component({
  selector: 'app-size-view',
  templateUrl: './size-view.component.html',
  styleUrls: ['./size-view.component.css']
})
export class SizeViewComponent implements OnInit {
  isLoading:boolean = false;
  sizes:SizeModel[]=[];
  columnList = ["sizeName", "actions"]
   /*
   * Table items
   *
   * */dataSource:MatTableDataSource<SizeModel> = new MatTableDataSource(this.sizes);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private sizeService:SizeService,
    private notifyService:NotifyService,
    private matDialog: MatDialog
  ) { }
  confirmDelete(item: SizeModel): void {
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(s => {
        if (s) {
          this.sizeService.deleteSize(Number(item.sizeId))
            .subscribe(s => {
              this.dataSource.data = this.dataSource.data.filter(b => b.sizeId != item.sizeId);
              this.notifyService.success("Size has been Deleted", "DISMISS")
            }, Error => {
              this.notifyService.fail("Failed to Delete Size", "DISMISS")
            });
        }
      })
  }
 
  ngOnInit(): void {
    this.isLoading=true;
    this.sizeService.get()
    .subscribe(
      r=>{
        this.sizes = r;
        this.dataSource.data = this.sizes;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator= this.paginator;
        this.isLoading=false;
      },
      err=>{
        this.isLoading=false;
        this.notifyService.fail("Failed to load Size", "DISMISS");
        throwError(err.error||err);

      }
    )
  }

}
