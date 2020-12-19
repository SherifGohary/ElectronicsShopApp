import { Injectable } from '@angular/core';
import { ToastrService} from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private toastrService: ToastrService
  ) { }

  showSuccess(message?: string, title?: string, override?: any) {
    this.toastrService.success(message, title, override);
  }

  showSuccessHtml(message?: string, title?: string) {
    this.toastrService.success(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showInfo(message?: string, title?: string, override?: any) {
    this.toastrService.info(message, title, override);
  }
  
  showInfoHtml(message?: string, title?: string) {
    this.toastrService.info(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showError(message?: string, title?: string, override?: any) {
    this.toastrService.error(message, title, override);
  }

  showErrorHtml(message?: string, title?: string) {
    this.toastrService.error(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showWarning(message?: string, title?: string, override?: any) {
    this.toastrService.warning(message, title, override);
  }

  showWarningHtml(message?: string, title?: string) {
    this.toastrService.warning(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }
}
