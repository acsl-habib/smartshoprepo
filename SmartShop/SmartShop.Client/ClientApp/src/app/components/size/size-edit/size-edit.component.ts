import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { SizeModel } from 'src/app/models/data/size-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { SizeService } from 'src/app/services/data/size.service';

@Component({
  selector: 'app-size-edit',
  templateUrl: './size-edit.component.html',
  styleUrls: ['./size-edit.component.css']
})
export class SizeEditComponent implements OnInit {

  Size: SizeModel = {};
  constructor(
    private sizeService:SizeService,
    private notifyService:NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  edit(Form: NgForm): void {
    this.sizeService.editSize(this.Size)
    .subscribe(s => {
      Form.form.markAsUntouched();
      this.notifyService.success("Succeeded to Update Size", "DISMISS");
    }, error => {
      this.notifyService.fail("Failed to Update Size", "DISMISS");
    });
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.sizeService.getSizeById(id)
    .subscribe( s =>{
      this.Size = s;
    }, error => {
      this.notifyService.fail("Failed to load Size", "DISMISS");
    })
}

}
