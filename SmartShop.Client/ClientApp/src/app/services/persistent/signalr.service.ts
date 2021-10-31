import { EventEmitter, Output } from '@angular/core';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { ENGINE_METHOD_PKEY_ASN1_METHS } from 'constants';
import { resolve } from 'dns';
import { BehaviorSubject } from 'rxjs';
import { AppConstants } from '../../config/app-constants';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  connection!: HubConnection;
  orderMessage!: BehaviorSubject<string | null>;
  @Output() orderEvent: EventEmitter<string> = new EventEmitter<string>();
  get emitter() {
    return this.orderEvent;
  }
  /*
   * Initialize Connection
   *
   * */

  initiateConnection(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.connection = new HubConnectionBuilder()
        .withUrl(`${AppConstants.webUrl}/orderHub`) // the SignalR server url
        .build();
      this.connection.on("orderCreated", data => {
        this.orderMessage.next("New order arrived");
        this.orderEvent.emit("orderCreated")
      });
      this.connection
        .start()
        .then(() => {
          console.log(`SignalR connection success! connectionId: ${this.connection.connectionId} `);
          resolve();
        })
        .catch((error) => {
          console.log(`SignalR connection error: ${error}`);
          reject();
        });
    });
  }
  constructor() {
    //this.initializeConnection();
    this.orderMessage = new BehaviorSubject<string | null>(null);
  }
}
