import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/authentication/user-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  data!: UserModel;
  constructor() {
    //do nothing
  }
  ngOnInit() {
    () => {/**/}
  }
}
