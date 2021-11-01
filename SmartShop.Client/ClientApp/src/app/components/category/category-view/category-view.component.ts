import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from '../../../dialogs/confirm-dialog/confirm-dialog.component';
import { CategoryModel } from '../../../models/data/category-model';

import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';



@Component({
  selector: 'app-category-view',
  templateUrl: './category-view.component.html',
  styleUrls: ['./category-view.component.css']
})
export class CategoryViewComponent implements OnInit {

  isLoading: boolean = false;
  categories: CategoryModel[] = [];
  columnList = ["categoryName","subcategories", "actions"]
  /*
   * Table items
   *
   * */
  dataSource: MatTableDataSource<CategoryModel> = new MatTableDataSource(this.categories);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  constructor(
    private categoryService: CategoryService,
    private notifyService: NotifyService,
    private matDialogRef: MatDialog
  ) { }
  /*
   * methods
   * 
   * */
  getSubcategories(data: CategoryModel) {
    return data
      .subcategories?.map(x => `<span>${x.subcategoryName}</span>`)
      .join(' ')
  }
  /*
   * Handlers
   *
   * */
  confirmDelete(item: CategoryModel): void {
    this.matDialogRef.open(ConfirmDialogComponent,
      { width: '450px' })
      .afterClosed()
      .subscribe(r => {
        if (r) {
          this.categoryService.delete(Number(item.categoryId))
            .subscribe(r => {
              this.dataSource.data = this.dataSource.data.filter(x => x.categoryId != item.categoryId);
              this.notifyService.success("Data Successfully deleted", "DISMISS");
            })
        }
      },
        err => {
          this.notifyService.fail("Failed to delete data", "DISMISS");
          throwError(err.error || err);
        }
      )
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.categoryService.getInclude()
      .subscribe(
        r => {
          this.categories = r;
          this.dataSource.data = this.categories;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          this.isLoading = false;
        },
        err => {
          this.isLoading = false;
          this.notifyService.fail("Failed to load categories", "DISMISS");
          throwError(err.error || err);

        }
      )
  }
}
