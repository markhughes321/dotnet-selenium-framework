# Run all tests
test:
	dotnet test UITests/UITests.csproj

# Run only tests tagged as Smoke (Category=Smoke)
test-smoke:
	dotnet test UITests/UITests.csproj --filter "Category=Smoke"

# Run only tests tagged as Regression
test-regression:
	dotnet test UITests/UITests.csproj --filter "Category=Regression"

# Serve Allure report locally
report:
	allure serve UITests/bin/Debug/net6.0/allure-results

# Generate static Allure HTML report
generate-report:
	allure generate UITests/bin/Debug/net6.0/allure-results --clean -o allure-report
	open allure-report/index.html
