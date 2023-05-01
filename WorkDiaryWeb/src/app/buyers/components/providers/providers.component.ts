import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { Provider } from '../../models/Provider';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { ProvidersService } from '../../services/providers.service';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.css']
})
export class ProvidersComponent implements OnInit {

  ServiceProviders: Provider[] = [];
  filteredProviders: Provider[] = [];
  searchTerm: string = '';

  constructor(private userService: UserService,
              private router: Router,
              private cacheStorage: CacheStorageService,
              private providerService: ProvidersService) { }

  ngOnInit() {
    var currentUserId = this.cacheStorage.get("User").USER_ID;

    this.getServiceProvidersByBuyer(currentUserId);
  }

  onSearchTermChange() {
    this.filteredProviders = this.ServiceProviders.filter((provider: any) =>
      provider.FULL_NAME.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  getServiceProvidersByBuyer(buyerId: number) {
    this.providerService.getProvidersByBuyer(buyerId).subscribe(
      (response: any[]) => {
        this.ServiceProviders = response;
        this.filteredProviders = this.ServiceProviders;
        console.log(this.ServiceProviders);
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  viewProfile(provider: number) {
    this.userService.userId = provider;
    this.router.navigate(['/buyers/provProfile']);
  }
}
