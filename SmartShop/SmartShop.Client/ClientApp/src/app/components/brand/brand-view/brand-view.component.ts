import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
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
  columnList = ["brandName", "actions"]
  /*
   * Table items
   *
   * */
  dataSource:MatTableDataSource<BrandModel> = new MatTableDataSource(this.brands);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private brandService:BrandService,
    private notifyService:NotifyService
  ) { }

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
