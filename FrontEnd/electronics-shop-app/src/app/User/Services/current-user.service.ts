import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
import { Role } from '../Models/role.enum';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private notificationService: NotificationService,
    ) { }

  isLoggedIn(): boolean {    
    let user = this.getCurrentUser();
    return (user != null);
  }

  getCurrentUser(): User {
    let user = <User>JSON.parse(localStorage.getItem(this.currentUser));
    return user;
  }

  public isAdmin(): boolean{
    let user =this.getCurrentUser();
    return user.role == Role.Admin;
  }

  getCurrentUserIdString(): string {
    let result: string; 
    let user = this.getCurrentUser();
        
    if(user) {
        result = user.id.toString();
    }
    return result;
  }

  logOut(showAuthError: boolean = false) {
    localStorage.setItem(this.currentUser, null);
    if(showAuthError) {
      this.notificationService.showError("error");
    }
    this.router.navigate(['user/login']);
  }

  private currentUser: string = 'currentUser';
  //User: UserLoggedIn;
}
