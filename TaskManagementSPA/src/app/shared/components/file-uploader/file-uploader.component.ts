import { Component, Input, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

type UploadEmitterType = {
  uploading: boolean;
  progress: number;
  success: boolean;
};

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css'],
})
export class FileUploaderComponent implements OnInit, OnDestroy {
  @Input() imgUrl?: string;
  @Input() uploadEnabled = false;
  @Output() onUploading = new EventEmitter<UploadEmitterType>();
  subscription = new Subject();

  constructor(private api: ApiService) {}

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.subscription.next();
    this.subscription.complete();
  }

  uploadFile(file: File): void {
    this.onUploading.emit({ uploading: true, success: false, progress: 0 });

    this.api
      .uploadProfilePicture(file)
      .pipe(takeUntil(this.subscription))
      .subscribe(
        (res) => console.log(res),
        (error) => {
          console.log('shit happened', error);
        }
      );
  }

  handleProfileChange(event: any): void {
    if (event.target?.files?.length > 0) {
      this.uploadFile(event.target.files[0]);
    }
  }
}
