import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';
import { Provider } from '../../models/Provider';

@Component({
  selector: 'app-provider-profile',
  templateUrl: './provider-profile.component.html',
  styleUrls: ['./provider-profile.component.scss']
})
export class ProviderProfileComponent {

  user:Provider | undefined;

  constructor(private userService: UserService) { }

  ngOnInit() {
    // console.log(this.userService.userId);
    this.getUserByProfile(this.userService.userId);
  }

  getUserByProfile(provider_id:number) {
    this.userService.getUserById(provider_id).subscribe(
      (response:any) => {
        this.user = response;
        console.log(this.user);
      },
      (error:any) => {
        console.error(error);
      }
    )
  }

}
