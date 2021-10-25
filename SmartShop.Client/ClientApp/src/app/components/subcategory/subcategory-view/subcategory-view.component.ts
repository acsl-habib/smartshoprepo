import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, _MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from '../../../dialogs/confirm-dialog/confirm-dialog.component';
import { CategoryModel } from '../../../models/data/category-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-subcategory-view',
  templateUrl: './subcategory-view.component.html',
  styleUrls: ['./subcategory-view.component.css']
})
export class SubcategoryViewComponent implements OnInit {
  isLoading = false;
  categories: CategoryModel[] = [];
  /*
   * For mat-table
   * 
   * */
  subcategories: SubcategoryModel[] = [];
  dataSource: MatTableDataSource<SubcategoryModel> = new MatTableDataSource(this.subcategories);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["subcategoryName", "categoryId", "actions"];
  constructor(
    private subcategoryService: SubcategoryService,
    private categoryService: CategoryService,
    private notifyService: NotifyService,
    private dailogRef: MatDialog
  ) { }
  delete(item: SubcategoryModel) {
    this.dailogRef.open(ConfirmDialogComponent, {
      width: "400px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.subcategoryService.delete(Number(item.subcategoryId))
            .subscribe(
              r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.subcategoryId != item.subcategoryId);
                this.notifyService.success("Item deleted", "DISMISS")
              },
              err => {
                this.notifyService.fail("Failed to delete item", "DISMISS");
                throwError(err.error || err);
              });
        }
      });
  }
  /*
   * Methods
   *
   * */
  getCategoryName(id: number) {
    let category = this.categories.find(x => x.categoryId == id);
    return category?.categoryName;
  }
  /*
   * Lifecycle event
   *
   * */
  ngOnInit(): void {
    this.isLoading = true;
    this.subcategoryService.get()
      .subscribe(
        r => {
          this.subcategories = r;
          this.dataSource.data = this.subcategories;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        err => {
          this.notifyService.fail("Failed to load subcategory data", "DISMISS");
          throwError(err.error || err);
        }
    );
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
        this.isLoading = false;
      }, err => {
        this.isLoading = false;
        this.notifyService.fail("Failed to load category data", "DISMISS");
        throwError(err.error || err);
      });
  }

}
