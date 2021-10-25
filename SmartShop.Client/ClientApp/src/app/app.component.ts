import { Component, OnInit } from '@angular/core';
import { NotifyService } from './services/common/notify.service';
import { SignalrService } from './services/persistent/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ClientApp';
  constructor(
    private signalRSevice: SignalrService,
    private notifyService: NotifyService
  ) { }
  ngOnInit() {
    this.signalRSevice.orderMessage
      .subscribe(s => {
        if(s)
          this.notifyService.success(s ?? "NA", "DISMISS");
      });
  }
}
