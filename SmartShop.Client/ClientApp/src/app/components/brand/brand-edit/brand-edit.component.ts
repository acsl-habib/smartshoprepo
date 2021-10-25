import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BrandModel } from 'src/app/models/data/brand-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BrandService } from 'src/app/services/data/brand.service';

@Component({
  selector: 'app-brand-edit',
  templateUrl: './brand-edit.component.html',
  styleUrls: ['./brand-edit.component.css']
})
export class BrandEditComponent implements OnInit {

  Brand: BrandModel = new BrandModel();
  constructor(
    private brandService:BrandService,
    private notifyService:NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  edit(Form: NgForm): void {
    this.brandService.update(this.Brand)
    .subscribe(s => {
      Form.form.markAsUntouched();
      this.notifyService.success("Succeeded to Update Brand", "DISMISS");
    }, error => {
      this.notifyService.fail("Failed to Update Brand", "DISMISS");
    });
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.brandService.getById(id)
    .subscribe( s =>{
      this.Brand = s;
    }, error => {
      this.notifyService.fail("Failed to load Brand", "DISMISS");
    })
}

}
