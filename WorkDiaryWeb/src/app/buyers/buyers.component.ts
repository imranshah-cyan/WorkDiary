import { Component } from '@angular/core';
import { CacheStorageService } from '../Shared/services/CacheStorage.service';

@Component({
  selector: 'app-buyers',
  templateUrl: './buyers.component.html',
  styleUrls: ['./buyers.component.scss']
})
export class BuyersComponent {

  currentUserName:string = "";

  constructor(private cacheStorage:CacheStorageService) {}

  ngOnInit() {
    this.currentUserName = this.cacheStorage.get("User").USER_NAME;
  }
}
