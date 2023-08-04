# URL Shortener Console Application

The URL Shortener Console Application is a simple tool that allows users to shorten long URLs and retrieve the original long URL from the shortened version. It uses a custom algorithm to generate short codes based on the length of the original long URL.

## How to Use

1. Run the application from the command line or any C# development environment.
2. Enter the long URL you want to shorten when prompted.
3. The application will generate a short code based on the length of the long URL and display the shortened URL in the format: `https://www.domainName.com/{shortCode}`.

## Retrieving Long URL from Short URL

1. To retrieve the original long URL from a shortened URL, enter the shortened URL when prompted.
2. The application will retrieve the original long URL associated with the shortened version and display it.

## Notes

- The application generates short codes with a prefix "1", "2", or "3" based on the length of the original long URL, along with a random 7-digit code to create a unique short code.
- The application uses a `Dictionary` to store the mapping between short codes and long URLs.

## Author

- Huiyu Shao

## License

- This project is licensed under the [MIT License](LICENSE).
