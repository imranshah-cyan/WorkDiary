import { Component } from '@angular/core';
import { CacheStorageService } from '../Shared/services/CacheStorage.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-buyers',
  templateUrl: './buyers.component.html',
  styleUrls: ['./buyers.component.scss']
})
export class BuyersComponent {

  currentUserName:string = "";

  constructor(private cacheStorage:CacheStorageService,
              private router: Router) {}

  ngOnInit() {
    this.currentUserName = this.cacheStorage.get("User").USER_NAME;
  }

  logout() {
    this.cacheStorage.remove("User");
    this.cacheStorage.clear();
    this.router.navigate(['']);
  }


}
