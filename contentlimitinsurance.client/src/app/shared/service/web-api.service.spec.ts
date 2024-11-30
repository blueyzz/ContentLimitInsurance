import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { WebAPIService } from './web-api.service';

describe('WebAPIService', () => {
  let service: WebAPIService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [WebAPIService]
    });
    service = TestBed.inject(WebAPIService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should perform GET request', () => {
    const dummyResponse = { data: 'test data' };
    service.get('dummy/url').subscribe(response => {
      expect(response).toEqual(dummyResponse);
    });
    const req = httpMock.expectOne('dummy/url');
    expect(req.request.method).toBe('GET');
    req.flush(dummyResponse);
  });

  it('should perform POST request', () => {
    const dummyResponse = { data: 'test data' };
    const dummyModel = { key: 'value' };
    service.post('dummy/url', dummyModel).subscribe(response => {
      expect(response).toEqual(dummyResponse);
    });
    const req = httpMock.expectOne('dummy/url');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(dummyModel);
    req.flush(dummyResponse);
  });

  it('should handle errors', () => {
    const errorResponse = new ErrorEvent('Network error');
    service.get('dummy/url').subscribe(
      () => fail('expected an error, not data'),
      error => {
        expect(error.error).toEqual(errorResponse);
      }
    );
    const req = httpMock.expectOne('dummy/url');
    req.error(errorResponse);
  });
});
