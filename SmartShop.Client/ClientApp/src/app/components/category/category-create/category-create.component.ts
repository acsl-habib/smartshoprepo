import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {

  category: CategoryModel = new CategoryModel();

  constructor(
    private categoryService: CategoryService,
    private notifyService: NotifyService
  ) { }

  save(f: NgForm): void {
    this.categoryService.create(this.category)
      .subscribe(r => {
        this.category = new CategoryModel();
        f.form.markAsUntouched();
        f.form.reset({});
        this.notifyService.success("Succeeded to save data", "DISMISS");
      }
        , err => {
          this.notifyService.fail("Failed to Create Category", "DISMISS");
          throwError(err.error || err);
        })
  }

  ngOnInit(): void {
    () => {/* */}
  }

}
