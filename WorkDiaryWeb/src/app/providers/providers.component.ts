import { Component } from '@angular/core';
import { CacheStorageService } from '../Shared/services/CacheStorage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss']
})
export class ProvidersComponent {

  currentUserName: string = "";

  constructor(private cacheStorage: CacheStorageService,
              private router: Router) { }

  ngOnInit() {
    this.currentUserName = this.cacheStorage.get("User").USER_NAME;
  }

  logout() {
    this.cacheStorage.remove("User");
    this.cacheStorage.clear();
    this.router.navigate(['']);
  }

}
