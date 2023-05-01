import { Component } from '@angular/core';
import { CacheStorageService } from '../Shared/services/CacheStorage.service';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss']
})
export class ProvidersComponent {

  currentUserName: string = "";

  constructor(private cacheStorage: CacheStorageService) { }

  ngOnInit() {
    this.currentUserName = this.cacheStorage.get("User").USER_NAME;
  }
}
