import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CategoryModel } from '../../../models/data/category-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
  category: CategoryModel = new CategoryModel();

  constructor(
    private categoryService: CategoryService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }

  update(f: NgForm): void {
    this.categoryService.update(this.category)
      .subscribe(r => {
        f.form.markAsUntouched();
        this.notifyService.success("Succeeded to update", "DISMISS");
      }, err => {
        this.notifyService.fail("Failed to update", "DISMISS");
      })
  }

  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.categoryService.getById(id)
      .subscribe(r => {
        //console.log(r);

        this.category = r;
      }, err => {
        this.notifyService.fail("Failed to load project", "DISMISS");
      })
  }


}
